using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
    int colorAmount;
    int maxCountColor;
    Color[] colors;
    Dictionary<Color, int> dictionary = new Dictionary<Color, int>();

    public ColorGenerator(int shelvesAmount)
    {
        colorAmount = shelvesAmount;
        colors = new Color[colorAmount];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Random.ColorHSV();
            dictionary.Add(colors[i], 0);
        }
    }

    public Color SetColor(int shelvesCapacity)
    {
        var rnd = Random.Range(0, colors.Length);
        if (dictionary[colors[rnd]] < shelvesCapacity)
        {
            dictionary[colors[rnd]] += 1;
            return colors[rnd];
        }
        else
        {
            dictionary.Remove(colors[rnd]);
            colors = colors.Where((s, index) => index != rnd).ToArray();
            return colors[0]; // Иногда одного цвета больше на 1. Переделать без Linq выражения.
        }
        
    }
    
}
