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
using System.Web.Script.Serialization;



namespace protocol
{
   

    public class AppClient
    {
        

        public static  String IPADDRESS = "127.0.0.1";
        public static  int PORT = 4001;
 
        public AppClient()
        {
            //        socket = new Socket(IPADDRESS, PORT);
            //        input = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            //        output = new PrintWriter(socket.getOutputStream(), true);
        }

        

        public MensajeRS sendRequest(Mensaje mensajeRQ) {

        int attemps = 0;
        try {
            
            
            
            IPAddress ipAddress = IPAddress.Parse(IPADDRESS);
            TcpClient tcpClient = new TcpClient(IPADDRESS, PORT);
            NetworkStream networkStream =  tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            StreamReader streamReader = new StreamReader(networkStream);


            String response;

            do
            {

                streamWriter.WriteLine(mensajeRQ.asTexto());

                streamWriter.Flush();

                response = streamReader.ReadLine();

                Console.WriteLine("Received data: " + response + "\n");
                attemps++;
                
                if (response != null)
                {
                    break;
                }
            } while (attemps <= 5);
            streamWriter.WriteLine("FIN");
            streamWriter.Flush();
            
            

            
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

       


        
        
    }
}
