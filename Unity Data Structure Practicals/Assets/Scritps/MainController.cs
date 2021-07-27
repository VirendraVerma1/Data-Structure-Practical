using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    
    void Start()
    {
        UseLinkedList();
    }

    public LinkedList newList;
    void UseLinkedList()
    {
        //add new data
        for(int i=0;i<10;i++)
        {
            string random = Random.Range(0, 10).ToString();
            newList.add(random);
        }

        //print data
        for (int i=0;i< newList.length();i++)
        {
            print(newList.intconvert(newList.get(i)));
        }

        print("Length=" + newList.length());
        newList.pop(1);
        newList.pop();
        print("After Pop Length=" + newList.length());

        
        newList.clear();
        print("After Clear Length=" + newList.length());
    }


    
}
