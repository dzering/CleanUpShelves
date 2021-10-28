using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController
{
    GameObject book;
    ShelfView shelf;
    BookView[] books;

    Vector3[] shelfSpace;
    Vector3 bookSize;
    Vector3 shelfSize;

    float spaceBetweenBooks = 0.1f;
    int shelfCapacity;

    BookView[] Books { get => books; set => books = value; }

    public ShelfController(ShelfView shelf)
    {
        this.shelf = shelf;
        this.book = Resources.Load("Book") as GameObject;

        bookSize = GetBookSize();
        shelfSize = GethShelfSize();
        shelfCapacity = GetShelfCapacity();

        shelfSpace = new Vector3[shelfCapacity];
        Books = new BookView[shelfCapacity];
        shelf.Books = Books;

        FillShelf();

    }

    void FillShelf()
    {

        for (int i = 0; i < shelfCapacity; i++)
        {
            Vector3 center = shelf.transform.position;

            shelfSpace[i] = new Vector3((shelf.transform.position.x - shelfSize.x/2 + bookSize.x/2) + (bookSize.x + spaceBetweenBooks) * i, (shelf.transform.position.y + shelfSize.y / 2 + bookSize.y / 2), shelf.transform.position.z);
            var newBook = GameObject.Instantiate(book);
            var view = newBook.GetComponent<BookView>();
            view.ID = 1;
            view.Shelf = shelf;
            Books[i] = view;

            newBook.transform.parent = shelf.transform;
            newBook.transform.position = shelfSpace[i];

            var renderer = newBook.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV(0, 1);
            view.Color = renderer.material.color;
        }
    }


    int GetShelfCapacity()
    {
        return (int)Mathf.Round(shelfSize.x / (bookSize.x + spaceBetweenBooks));
    }

    Vector3 GetBookSize()
    {
        var item = GameObject.Instantiate(book);
        var bookSize = item.GetComponent<Collider>().bounds.size;
        GameObject.Destroy(item);
        return bookSize;
    }

    Vector3 GethShelfSize()
    {
        return shelf.GetComponent<Collider>().bounds.size;
    }
}
