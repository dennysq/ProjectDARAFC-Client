using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using protocol.clienteApp;
using System.Net;
using System.Threading;

namespace protocol
{
    public class StateObject {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

    public class AppClient
    {
        private Socket socket;
        /*private StreamWriter  output;
        private StreamReader input;*/
        public static  String IPADDRESS = "127.0.0.1";
        public static  int PORT = 4001;
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        //private static String response = String.Empty;
        private static String response = null;


        public AppClient()
        {
            //        socket = new Socket(IPADDRESS, PORT);
            //        input = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            //        output = new PrintWriter(socket.getOutputStream(), true);
        }

        

        public MensajeRS sendRequest(Mensaje mensajeRQ) {

        //String response = null;
        int attemps = 0;
        try {
            
            //IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
            IPAddress ipAddress = IPAddress.Parse(IPADDRESS);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.BeginConnect( remoteEP, new AsyncCallback(ConnectCallback), socket);
            connectDone.WaitOne();

            /*Send(socket, "This is a test<EOF>");
            sendDone.WaitOne();

            // Receive the response from the remote device.
            Receive(socket);
            receiveDone.WaitOne();

            // Write the response to the console.
            Console.WriteLine("Response received : {0}", response);

            // Release the socket.
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();*/

            do
            {
                Send(socket, mensajeRQ.asTexto() + "<EOF>");
                sendDone.WaitOne();

                Receive(socket);
               // receiveDone.WaitOne();
                attemps++;
                
                if (response != null)
                {
                    break;
                }
            } while (attemps <= 5);

            Send(socket, "FIN");
            sendDone.WaitOne();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

            
            if (response != null) {
                MensajeRS mensajeRS = new MensajeRS();
                if (mensajeRS.build(response)) {
                    return mensajeRS;
                }
            }
        } catch (IOException ex) {
            Console.Out.WriteLine(ex.ToString());
            //Logger.getLogger(AppClient.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

        private static void ConnectCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete the connection.
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.
            connectDone.Set();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }


        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
    }
}
