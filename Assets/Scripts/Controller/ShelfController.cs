using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController
{
    BookView book;
    ShelfView shelf;
    BookView[] books;

    Vector3[] shelfSpace;
    Vector3 bookSize;
    Vector3 shelfSize;

    float spaceBetweenBooks = 0.1f;
    int shelfCapacity;

    BookView[] Books { get => books; set => books = value; }

    public ShelfController(ShelfView shelf, BookView book)
    {
        this.shelf = shelf;
        this.book = book;

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
            var newBook = GameObject.Instantiate(Resources.Load("Book") as GameObject);
            var item = newBook.GetComponent<BookView>();
            item.ID = 1;
            item.Shelf = shelf;
            Books[i] = item;

            newBook.transform.parent = shelf.transform;
            newBook.transform.position = shelfSpace[i];
            var renderer = newBook.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV(0, 1);
        }
    }


    int GetShelfCapacity()
    {
        return (int)Mathf.Round(shelfSize.x / (bookSize.x + spaceBetweenBooks));
    }

    Vector3 GetBookSize()
    {
       return book.GetComponent<Collider>().bounds.size;
    }

    Vector3 GethShelfSize()
    {
        return shelf.GetComponent<Collider>().bounds.size;
    }
}
