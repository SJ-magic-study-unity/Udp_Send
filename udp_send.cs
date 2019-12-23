/************************************************************
UnityでUDPを送信してみる
	https://qiita.com/nenjiru/items/d9c4e8a22601deb0425b
************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Sockets;
using System.Text;

/************************************************************
************************************************************/
public class udp_send : MonoBehaviour
{
    [SerializeField] string host = "127.0.0.1";
	[SerializeField] int port = 12353;
	[SerializeField] string udp_message = "/UnityApp/Scene<p>techScene";
    private UdpClient client;

    void Start ()
    {
        client = new UdpClient();
        client.Connect(host, port);
    }

    void Update ()
    {
		if(client == null) return;
		
		byte[] dgram = Encoding.UTF8.GetBytes(udp_message);
		
		try{
			client.Send(dgram, dgram.Length);
			
		}catch(SocketException){
			/********************
			UdpClient.Sendの投げる例外
				https://msdn.microsoft.com/ja-jp/library/82dxxas0(v=vs.110).aspx
			********************/
			Debug.Log("Error Sending Udp(accessing to Socket). I guess : No client??");
		}
	}

	void OnDestroy () {
		client.Close();
	}
	
    void OnApplicationQuit()
    {
		
    }
}
