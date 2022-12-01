using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileStream : MonoBehaviour
{
    Renderer cubeColor;
    Vector2 worldPosition;

    bool drag;

    float r;
    float g;
    float b;

    void Start()
    {
        cubeColor = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {        
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (drag)
            gameObject.transform.localPosition= worldPosition;
    }

    private void OnMouseDown()
    {
        r = Random.Range(0.01f, 1.00f);
        g = Random.Range(0.01f, 1.00f);
        b = Random.Range(0.01f, 1.00f);
        cubeColor.material.color = new Color(r, g, b, 1);
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
    }

    public void WriteString()
    {        
        string path = "Assets/problem3/Notepad/pos_and_material.txt";
        
        StreamWriter writer = new StreamWriter(path, false);
        
        writer.WriteLine(gameObject.transform.position.x);
        writer.WriteLine(gameObject.transform.position.y);        
        writer.WriteLine(r);
        writer.WriteLine(g);
        writer.WriteLine(b);

        writer.Close();
    }

    public void ReadString()
    {
        string path = "Assets/problem3/Notepad/pos_and_material.txt";

        StreamReader reader = new StreamReader(path);
        string PosX = reader.ReadLine();
        string PosY = reader.ReadLine();
        string R = reader.ReadLine();
        string G = reader.ReadLine();
        string B = reader.ReadLine();

        gameObject.transform.position = new Vector3(float.Parse(PosX),float.Parse(PosY),0);
        cubeColor.material.color = new Color(float.Parse(R), float.Parse(G), float.Parse(B), 1);
        
        reader.Close();
    }
}