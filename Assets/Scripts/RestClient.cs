using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RestClient
{
    private string endpoint = "https://localhost:5001/game";

    string responseValue = string.Empty;


    private static RestClient instance = null;

    public static RestClient Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RestClient();
            }
            return instance;
        }
    }


    public string getUsername(string username)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(endpoint + "/" + username);
        r.Method = "GET";

        using (HttpWebResponse res = (HttpWebResponse)r.GetResponse())
        {
            if (res.StatusCode != HttpStatusCode.OK && res.StatusCode != HttpStatusCode.NoContent)
                Debug.Log("Status != OK");
            else
            {
                using (Stream responseStream = res.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            return responseValue;
                        }
                    }

                }
            }
        }
        return string.Empty;
    }

    public string addBoard(Board board)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(endpoint);
        r.Method = "POST";
        r.ContentType = "application/json";


        byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(board));


        Stream requestStream = r.GetRequestStream();
        requestStream.Write(data, 0, data.Length);
        requestStream.Close();

        using (HttpWebResponse res = (HttpWebResponse)r.GetResponse())
        {
            if (res.StatusCode != HttpStatusCode.OK)
                Debug.Log("Status != OK");
            else
            {
                using (Stream responseStream = res.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            return responseValue;
                        }
                    }

                }
            }
        }
        return string.Empty;
    }

    public string checkPos(int x)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(endpoint+"/"+GameData.opponent+"/"+x);
        r.Method = "GET";

        using (HttpWebResponse res = (HttpWebResponse)r.GetResponse())
        {
            if (res.StatusCode != HttpStatusCode.OK)
                Debug.Log("Status != OK");
            else
            {
                using (Stream responseStream = res.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            return responseValue;
                        }
                    }

                }
            }
        }
        return string.Empty;
    }

    public void postWinner(string winner)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(endpoint+"/"+GameData.username);
        r.Method = "POST";
        r.ContentType = "application/json";


        byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(winner));


        Stream requestStream = r.GetRequestStream();
        requestStream.Write(data, 0, data.Length);
        requestStream.Close();

        using (HttpWebResponse res = (HttpWebResponse)r.GetResponse())
        {
            if (res.StatusCode != HttpStatusCode.OK)
                Debug.Log("Status != OK");
            else
            {
                using (Stream responseStream = res.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }

                }
            }
        }
    }

    public string getWinner(string username)
    {
        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(endpoint+"/winner");
        r.Method = "GET";

        using (HttpWebResponse res = (HttpWebResponse)r.GetResponse())
        {
            if (res.StatusCode != HttpStatusCode.OK && res.StatusCode != HttpStatusCode.NoContent)
                Debug.Log("Status != OK");
            else
            {
                using (Stream responseStream = res.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            return responseValue;
                        }
                    }

                }
            }
        }
        return string.Empty;
    }

}
