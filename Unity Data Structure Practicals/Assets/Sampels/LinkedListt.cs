using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListt : MonoBehaviour
{
    string LikedInsource = "https://www.geeksforgeeks.org/linked-list-set-1-introduction/";

    //linked list
    //Linked List is a linear data structure. Unlike arrays, linked list elements are not stored at a contiguous location; the elements are linked using pointers.


    //why linked list
    //1. array has upper limit but linked list is not
    //2. if we have to insert element in the starting, in array we have to shift all the element but in linked list we can add easily


    public Node head;

    void Start()
    {
        SimpleLinkedListInitializeManually();
        print("Finalized");
    }

    //list have one head then refer to next one
    void SimpleLinkedListInitializeManually()
    {
        LinkedListt list = new LinkedListt();

        list.head = new Node(1);//creating very first element so we use head
        Node first = new Node(2);
        Node second = new Node(3);

        list.head.next = first;//add reference to the other one in next node class
        first.next = second;//then in the first node class we refer to second one

        printList(list.head);
        
    }

    void printList(Node head)
    {
        Node n = head;
        while (n != null)
        {
            print(n.data);
            n = n.next;
        }
        
    }
}


//it is like bean class which create multiple small classes having their own reference in data
public class Node  //node class
{
    public int data;   //reference id
    public Node next;  //its class

    public Node(int d) //constructor that stores its single value in data
    {
        data = d;
    }
}
