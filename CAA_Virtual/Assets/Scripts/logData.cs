using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logData : MonoBehaviour {

    public InputField expName;
    public InputField partNumber;
    public InputField partAge;
    public InputField partGender;

    void Start()
    {
        
    }

    public void Savecsv() {

        string Name = expName.text;
        string Number = partNumber.text;
        string Age = partAge.text;
        string Gender = partGender.text;

        string filePath = "C:/Users/Jake/Documents/GitHub/CAA_Virtual/CAA_Virtual/Assets/Data/data.csv";
        string delimiter = ",";

        string[][] output = new string[][]{
             new string[]{"Experiment Name", "Participant Number", "Participant Age", "Participant Gender"},
             new string[]{Name, Number, Age, Gender}
         };
        int length = output.GetLength(0);
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        File.WriteAllText(filePath, sb.ToString());
    }
}
