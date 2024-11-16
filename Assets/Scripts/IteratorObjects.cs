using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteratorObjects<T,E>
{
    private List<T> selectorItems = new List<T>();
    private List<E> objects = new List<E>();
    private int currentIndex;

    public IteratorObjects(List<T> selectorItems, List<E> objects)
    {
        this.selectorItems = selectorItems;
        this.objects = objects;
        this.currentIndex = 0;
    }

    public void Next()
    {
        (selectorItems[currentIndex] as GameObject).GetComponent<SelectorItem>().Deselect();
        if (currentIndex == selectorItems.Count - 1) currentIndex = 0;
        else currentIndex++;
        (selectorItems[currentIndex] as GameObject).GetComponent<SelectorItem>().Select();
        Debug.Log("Index: " + currentIndex);
    }

    public void Previous()
    {
        (selectorItems[currentIndex] as GameObject).GetComponent<SelectorItem>().Deselect();
        if(currentIndex == 0) currentIndex = selectorItems.Count - 1;
        else currentIndex--;
        (selectorItems[currentIndex] as GameObject).GetComponent<SelectorItem>().Select();
        Debug.Log("Index: " + currentIndex);
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
