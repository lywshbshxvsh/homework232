using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{
    public int StudentId;

    public Student(int id)
    {
        StudentId = id;
    }
}

public class NewBehaviourScript : MonoBehaviour
{
    private Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();
    public int rows = 5;
    public int columns = 5;

    void Start()
    {
        int studentId = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Student newStudent = new Student(i + j);
                studentDictionary.Add(studentId, newStudent);
                studentId++;
            }
        }

        foreach (var studentEntry in studentDictionary)
        {
            Debug.Log("Student Id: " + studentEntry.Value.StudentId);
        }
    }
}
