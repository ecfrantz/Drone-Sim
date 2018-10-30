using System;
using CortexAccess;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DataRecordExp : MonoBehaviour {

    public Text output;
    static string path = "Assets/DataOut.txt";
    //StreamWriter writer = new StreamWriter(path, true);
    //const string OutFilePath = @"EEGLogger.csv";
    //private static FileStream OutFileStream;
    const string Username = "your_username";
    const string Password = "your_password";
    const string LicenseId = "your_license";
    const int DebitNumber = 2; // default number of debit

    // Use this for initialization
    //private void Start () {

    //}
	
	// Update is called once per frame
	public void Record () {
        output.text = "Please make sure the headset has good signal.";

        //writer.WriteLine("Testing testing 123");
        //writer.Close();

        // Delete Output file if existed
        //if (File.Exists(OutFilePath))
        //{
        //   File.Delete(OutFilePath);
        //}
        //OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);

        Process p = new Process();

        // Register Event
        //p.OnEEGDataReceived += OnEEGDataReceived;
        //p.SessionCtr.OnSubcribeEEGOK += OnEEGDataReceived;

        Thread.Sleep(10000); //wait for querrying user login, query headset
        if (String.IsNullOrEmpty(p.GetUserLogin()))
        {
            p.Login(Username, Password);
            Thread.Sleep(5000); //wait for logining
        }
        // Show username login
        output.text = "Username :" + p.GetUserLogin();

        if (p.AccessCtr.IsLogin)
        {
            // Send Authorize
            p.Authorize(LicenseId, DebitNumber);
            Thread.Sleep(5000); //wait for authorizing
        }
        //if (!p.IsHeadsetConnected())
        //{
        //    p.QueryHeadset();
        //    Thread.Sleep(10000); //wait for querying headset and create session
        //}
        //if (!p.IsCreateSession)
        //{
        //    p.CreateSession();
        //    Thread.Sleep(5000);
        //}
        //if (p.IsCreateSession)
        //{
        //    // Subcribe EEG data
        //    p.SubcribeData("eeg");
        //    Thread.Sleep(5000);
        //}

        //Thread.Sleep(10000);

        //// Unsubcribe stream
        //p.UnSubcribeData("eeg");
        //Thread.Sleep(3000);
        //// Close Out Stream
        ////OutFileStream.Dispose();
    }
}
