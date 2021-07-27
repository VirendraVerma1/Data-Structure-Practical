using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.IO;

public class LinkedList : MonoBehaviour
{
    public  SimpleNode head;
    public  void add( string data,GameObject go=null)
    {
        SimpleNode newNode = new SimpleNode(data,go);
        
        if (head == null)
            head = newNode;
        else
        {
            SimpleNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
    }

    public  void add_at_index( string data,int index, GameObject go = null)
    {
        SimpleNode newNode = new SimpleNode(data, go);
        
        if (head == null)
            head = newNode;
        else
        {
            int counter = 0;
            SimpleNode temp = head;
            SimpleNode prev = null;
            while (temp.next != null && counter<index)
            {
                prev = temp;
                temp = temp.next;
                counter++;
            }
            newNode.next = temp.next;
            temp.next = newNode;
        }
    }

    public void pop(int index=-1)
    {
        SimpleNode tempNode = head;
        SimpleNode prev = null;

        if(index==-1)
        {
            while (tempNode.next != null)
            {
                prev = tempNode;
                tempNode = tempNode.next;
            }
            prev.next = null;
        }
        else if(index==0)
        {
            SimpleNode newhead = tempNode.next;
            head = newhead;
        }
        else
        {
            int counter = 0;
            while(tempNode.next!=null)
            {
                if (counter == index - 1)
                    break;

                tempNode = tempNode.next;
                counter++;
            }
            if(tempNode.next!=null&&tempNode.next.next!=null)
                tempNode.next = tempNode.next.next;
        }
        
    }

    public void clear()
    {
        head = null;
    }


    public int length()
    {
        SimpleNode temp = head;
        int counter = 0;
        while(temp!=null)
        {
            temp = temp.next;
            counter++;
        }
        return counter;
    }

    public  SimpleNode get(int index)
    {
        SimpleNode current = head;
        if (index == 0)
            return current;
        int counter = 0;
        while (current != null)
        {
            current = current.next;
            if (counter == index-1)
                break;
            counter++;
        }
        return current;
    }

    public  int intconvert(SimpleNode newNode)
    {
        SimpleNode tempNode = newNode;
        int numberr=0;
        int number;
        if (int.TryParse(tempNode.data, out number))
            numberr = number;
        return numberr;
    }

    public  float floatconvert(SimpleNode newNode)
    {
        SimpleNode tempNode = newNode;
        float numberr = 0.0f;
        float number;
        if (float.TryParse(tempNode.data, out number))
            numberr = number;
        return numberr;
    }



}

public class SimpleNode  //node class
{
    public string data;
    public GameObject godata;
    public SimpleNode next;  //its class

    public SimpleNode(string dataa,GameObject go=null) //constructor that stores its single value in data
    {
        data = dataa;
        godata = go;
        next = null;
    }
}