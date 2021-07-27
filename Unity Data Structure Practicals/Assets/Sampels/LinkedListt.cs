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

    //important points
    //1. array is taken as a static data structure(residing in Data or Stack section) while linked list is taken as a dynamic data(residing in Heap section)


    public Node head;

    void Start()
    {
        SimpleLinkedListInitializeManually();
        print("Finalized");
    }

    //list have one head then refer to next one
    void SimpleLinkedListInitializeManually()
    {
        head = new Node(1);//creating very first element so we use head
        Node first = new Node(2);
        Node second = new Node(3);

        head.next = first;//add reference to the other one in next node class
        first.next = second;//then in the first node class we refer to second one

        pushInFront(10);
        insertAfter(first,20);
        append(100);
        deleteusingkey(3);
        deleteusingposition(2);
        printList();
        print("Length = " + getLength());
        print("Recursive Length = " + getCountRec(head));
    }

    void printList()
    {
        Node n = head;
        while (n != null)
        {
            print(n.data);
            n = n.next;
        } 
    }

    void pushInFront(int data) //time complexity of new node is O(1) 
    {
        Node newNode = new Node(data);
        newNode.next = head;
        head = newNode;
    }

    void insertAfter(Node prev_node, int data)//complexity O(1) 
    {
        if (prev_node == null)
            print("previous node is not present");

        Node new_node = new Node(data);
        new_node.next = prev_node.next;
        prev_node.next = new_node;
    }

    void append(int data)//complexity  O(n)
    {
        //creating new node
        Node new_node = new Node(data);

        //check head if null then make new node as a head
        if(head==null)
        {
            head = new_node;
            return;
        }

        //initialize new node next to null
        new_node.next = null;

        //initialize last node to head
        Node last_node = head;

        while(last_node.next !=null)
        {
            last_node = last_node.next;
        }

        
        last_node.next = new_node;
        return;
    }

    void deleteusingkey(int key)
    {
        Node temp, previous;
        temp = head;
        previous = null;

        //check if it is not a head
        if(temp!=null && temp.data==key)
        {
            head = temp.next;//just unlink the data
            return;
        }

        //we will automatically get the node in temp after the whole loop completion
        while(temp!=null && temp.data!=key)
        {
            previous = temp;
            temp = temp.next;
        }

        if(temp==null)//means not found the node having key
        {
            return;
        }

        previous.next = temp.next;//unlinking the temp node
    }

    void deleteusingposition(int pos)
    {
        Node temp = head;

        //check if head is not null
        if(temp==null)
        {
            return;
        }

        //chek if position is not 0
        if(pos==0)
        {
            head = temp.next;
            return;
        }

        //means pos is not 0 then use loop
        int index = 0;
        bool flag = true;

        while(flag&& temp.next!=null)
        {
            if (index == pos-2)
                flag = false;
            temp = temp.next;
            
            index++;
        }

        //check if that node is not null
        if( temp.next == null || temp.next.next == null)
        {
            return;
        }

        //print(temp.data+"data" +temp.next.next.data);
        //delete that node
        temp.next = temp.next.next;
    }

    int getLength()
    {
        Node n = head;
        int counter = 0;
        while(n!=null)
        {
            counter++;
            n = n.next;
        }
        return counter;
    }

    int getCountRec(Node node)
    {
        // Base case
        if (node == null)
            return 0;

        // Count is this node plus rest of the list
        return 1 + getCountRec(node.next);
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
        next = null;
    }
}
