using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Timers;
using WebSocket4Net;

namespace DAxZE
{
    public class WebsocketCore
    {
        private IPEndPoint localPoint;
        private Ping pingTest = new Ping();

        private WebSocket webSocket;
        private UDPForwarder uDPForwarder;

        private Timer timerSendStream;
        private Timer timerCreateConncet;
        private Timer timerCheckReviceState;
        private Timer timerTestNetworkLatency;

        private int reCheckStateCount;

        private string serverIP = string.Empty, serverPort = string.Empty;

        public ushort Local_port { get; set; } = 10800;

        public delegate void delegateElapsedEvent(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs);

        private class SendArgs
        {
            public byte[] buffer;
            public IPEndPoint remote_address;
        }

        /// <summary>
        /// Connect to server
        /// </summary>
        public async void ConnectToServer()
        {
            await Task.Run(() =>
            {
                Form1.MainForm.Invoke(new Action(() =>
                {
                    Form1.MainForm.metroComboBox1.Enabled
                        = Form1.MainForm.MetroTextBoxzCPort.Enabled
                        = Form1.MainForm.metroButtonCPort.Enabled = false;
                }));

                CloseConnect();

                timerCreateConncet = CreateTimer(CreateConnect, null, 500, true);
                timerCheckReviceState = CreateTimer(CheckRecviceState, null);
                timerTestNetworkLatency = CreateTimer(Test_NetworkLatency, null, 5000, true);
            });
        }

        /// <summary>
        /// Create webSocket connect
        /// </summary>
        private void CreateConnect(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs)
        {
            timerCreateConncet.Close();
            timerCreateConncet = null;

            if (webSocket == null)
            {
                serverIP = serverPort = string.Empty;
                Form1.MainForm.Invoke(new Action(() =>
                {
                    Form1.MainForm.MetroLabelNetworkLatency.Text =
                        Form1.MainForm.metroTextBox1.Text = string.Empty;
                    Form1.MainForm.MetroLabelState.Text = "正在申请 IP";
                }));

                localPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Local_port);

                webSocket = new WebSocket($"wss://{Form1.serverName}", null, null, null,
                    $"{Form1.AppName}/{Form1.AppVersion}"
                    );
                webSocket.Opened += new EventHandler(Websocket_Opened);
                webSocket.Error += new EventHandler<ErrorEventArgs>(Websocket_Error);
                webSocket.Closed += new EventHandler(Websocket_Closed);
                webSocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(Websocket_MessageReceived);
                webSocket.EnableAutoSendPing = true;
                webSocket.AutoSendPingInterval = 8000;
                webSocket.Open();
            }

            Form1.MainForm.Invoke(new Action(() =>
            {
                Form1.MainForm.metroComboBox1.Enabled
                    = Form1.MainForm.MetroTextBoxzCPort.Enabled
                    = Form1.MainForm.metroButtonCPort.Enabled = true;
            }));
        }

        /// <summary>
        /// Close connect
        /// </summary>
        public void CloseConnect()
        {
            if (timerSendStream != null)
            {
                timerSendStream.Close();
                timerSendStream = null;
            }
            if (uDPForwarder != null)
            {
                uDPForwarder.Stop();
                uDPForwarder = null;
            }
            if (timerCheckReviceState != null)
            {
                timerCheckReviceState.Close();
                timerCheckReviceState = null;
            }
            if (webSocket != null && (webSocket.State != WebSocketState.Closed || webSocket.State != WebSocketState.Closing))
            {
                if (timerCreateConncet != null)
                {
                    timerCreateConncet.Close();
                    timerCreateConncet = null;
                }
                webSocket.Close();
                webSocket = null;
            }
            if (timerTestNetworkLatency != null)
            {
                timerTestNetworkLatency.Close();
                timerTestNetworkLatency = null;
            }
        }

        /// <summary>
        /// Forward stream to game
        /// </summary>
        private void SendThStreamToGame(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs)
        {
            SendArgs args = sourceArgs as SendArgs;

            if (uDPForwarder == null)
            {
                uDPForwarder = new UDPForwarder(localPoint, args.remote_address);
            }
            else
            {
                uDPForwarder.Stop();
                uDPForwarder.ChangePoint(localPoint, args.remote_address);
            }
            uDPForwarder.SendToRemote(args.buffer);
            uDPForwarder.Start();

            if (uDPForwarder.State == UDPForwarder.RecviceState.Running)
            {
                timerSendStream.Close();
                timerSendStream = null;
            }
        }

        /// <summary>
        /// Check udp recvice state
        /// </summary>
        private void CheckRecviceState(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs)
        {
            if (uDPForwarder.State == UDPForwarder.RecviceState.Waiting)
            {
                if (reCheckStateCount < 1)
                {
                    Form1.MainForm.Invoke(new Action(() =>
                    {
                        Form1.MainForm.MetroLabelState.Text = "等待连接";
                        Form1.MainForm.MetroLabelMessage.Text = "少女离开了游戏，正在等待重连";
                        Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                    }));
                }
                else
                {
                    reCheckStateCount = 1;
                }
            }
            else if (uDPForwarder.State == UDPForwarder.RecviceState.Stop)
            {

                if (reCheckStateCount < 2)
                {
                    serverIP = serverPort = string.Empty;
                    Form1.MainForm.Invoke(new Action(() =>
                    {
                        Form1.MainForm.metroTextBox1.Text = string.Empty;
                        Form1.MainForm.MetroLabelState.Text = "连接断开";
                        Form1.MainForm.MetroLabelMessage.Text = "境界已关闭，需要重新获取";
                        Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                    }));
                }
                else
                {
                    reCheckStateCount++;
                    if (reCheckStateCount > 6)
                    {
                        timerCheckReviceState.Enabled = false;
                    }
                }
            }
        }

        #region ----------------------------- Websocket Events -----------------------------
        /// <summary>
        /// Receive message from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Websocket_MessageReceived(object sender, MessageReceivedEventArgs args)
        {

            if (args.Message.Length < 1)
            {
                return;
            }
            //Console.WriteLine(args.Message);
            string[] msgData = args.Message.Split(' ');
            if (msgData.Length > 1)
            {
                string state = msgData[0];
                string[] ipData = msgData[1].Split(':');

                if (ipData.Length < 2)
                {
                    Form1.MainForm.Invoke(new Action(() =>
                    {
                        Form1.MainForm.MetroLabelState.Text = "申请IP失败";
                        Form1.MainForm.MetroLabelMessage.Text = "没有申请到 IP";
                        Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                    }));
                    return;
                }

                serverIP = ipData[0];
                serverPort = ipData[1];

                Form1.MainForm.Invoke(new Action(() =>
                {

                    switch (state.ToUpper())
                    {
                        case "LISTEN":
                            if (uDPForwarder != null)
                            {
                                uDPForwarder.Stop();
                                uDPForwarder = null;
                            }
                            state = "等待连接";
                            Form1.MainForm.metroTextBox1.Text = $"{serverIP}:{serverPort}";
                            Form1.MainForm.MetroLabelMessage.Text = $"正在等待少女连接IP地址：{serverIP}，端口：{serverPort}";
                            Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                            break;

                        case "CONNECT":
                            if (timerSendStream != null)
                            {
                                timerSendStream.Close();
                                timerSendStream = null;
                            }
                            if (timerCheckReviceState != null)
                            {
                                timerCheckReviceState.Enabled = false;
                            }

                            state = "少女连接中";
                            Form1.MainForm.MetroLabelMessage.Text = "等待少女加入游戏...";
                            Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);

                            byte[] buffer = CreateThNetworkStream(Local_port, Convert.ToUInt16(serverPort));

                            SendArgs sendArgs = new SendArgs
                            {
                                buffer = buffer,
                                remote_address = new IPEndPoint(IPAddress.Parse(serverIP), Convert.ToUInt16(serverPort))
                            };
                            timerSendStream = CreateTimer(SendThStreamToGame, sendArgs, 200, true);

                            break;

                        case "CONNECTED":

                            if (uDPForwarder != null && uDPForwarder.State == UDPForwarder.RecviceState.Running)
                            {
                                if (timerCheckReviceState != null)
                                {
                                    timerCheckReviceState.Enabled = true;
                                    reCheckStateCount = 0;
                                }
                                state = "连接成功";
                                Form1.MainForm.MetroLabelMessage.Text = "少女加入了游戏DA☆ZE！";
                                Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                            }
                            else
                            {
                                if (timerCheckReviceState != null)
                                {
                                    timerCheckReviceState.Enabled = false;
                                }
                                state = "等待连接";
                                Form1.MainForm.MetroLabelMessage.Text = $"正在等待少女连接IP地址：{serverIP}，端口：{serverPort}";
                                Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                            }
                            break;

                        default:
                            Form1.MainForm.MetroLabelMessage.Text = args.Message;
                            break;
                    }

                    Form1.MainForm.MetroLabelState.Text = state;

                }));
            }
            else
            {
                Form1.MainForm.Invoke(new Action(() =>
                {
                    Form1.MainForm.MetroLabelState.Text = "服务器错误";
                    Form1.MainForm.MetroLabelMessage.Text = args.Message;
                    Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                }));
            }
        }

        /// <summary>
        /// Server Connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Websocket_Opened(object sender, EventArgs args) { }

        /// <summary>
        /// Server Disconnected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Websocket_Closed(object sender, EventArgs args)
        {
            try
            {
                Form1.MainForm.Invoke(new Action(() =>
                {
                    Form1.MainForm.metroTextBox1.Text =
                        Form1.MainForm.MetroLabelMessage.Text = string.Empty;
                    Form1.MainForm.MetroLabelState.Text = "少女已离线";
                    Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
                }));
                webSocket = null;
                serverIP = serverPort = string.Empty;
            }
            catch { }
        }

        /// <summary>
        /// Websocket error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Websocket_Error(object sender, ErrorEventArgs args)
        {
            Form1.MainForm.Invoke(new Action(() =>
            {
                Form1.MainForm.MetroLabelMessage.Text = args.Exception.Message;
                Form1.MainForm.ShowToolTip(Form1.MainForm.MetroLabelMessage, Form1.MainForm.MetroLabelMessage.Text);
            }));
        }

        #endregion

        #region ------------------------------ Test Events ------------------------------
        /// <summary>
        /// Test network latency
        /// </summary>
        public void Test_NetworkLatency(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs)
        {
            Form1.MainForm.Invoke(new Action(() =>
            {
                if (string.IsNullOrWhiteSpace(serverIP))
                {
                    Form1.MainForm.MetroLabelNetworkLatency.Text = string.Empty;
                    return;
                }

                PingReply reply = pingTest.Send(serverIP);
                switch (reply.Status)
                {
                    case IPStatus.Success:
                        Form1.MainForm.MetroLabelNetworkLatency.Text =
                            reply.RoundtripTime.ToString() + Form1.MainForm.MetroLabelNetworkLatency.Tag;
                        break;
                    case IPStatus.TimedOut:
                        Form1.MainForm.MetroLabelNetworkLatency.Text = "超时";
                        break;
                    default:
                        Form1.MainForm.MetroLabelNetworkLatency.Text = "失败";
                        break;
                }
            }));
        }
        #endregion

        #region ----------------------------- Extend Function -----------------------------
        /// <summary>
        /// Create touhou network connection stream
        /// </summary>
        /// <param name="local_port">10800</param>
        /// <param name="remote_port">Server remote port</param>
        /// <returns>Buffer stream</returns>
        private byte[] CreateThNetworkStream(ushort local_port, ushort remote_port)
        {
            byte[] buffer = new byte[9];
            byte[] local_port_buffer = BitConverter.GetBytes(local_port);
            byte[] remote_port_buffer = BitConverter.GetBytes(remote_port);
            byte[] buffer_length_buffer = BitConverter.GetBytes((ushort)buffer.Length);

            Array.Reverse(local_port_buffer);
            Array.Reverse(remote_port_buffer);
            Array.Reverse(buffer_length_buffer);

            Buffer.BlockCopy(local_port_buffer, 0, buffer, 0, local_port_buffer.Length);
            Buffer.BlockCopy(remote_port_buffer, 0, buffer, local_port_buffer.Length, remote_port_buffer.Length);
            Buffer.BlockCopy(buffer_length_buffer, 0, buffer, local_port_buffer.Length + remote_port_buffer.Length, buffer_length_buffer.Length);

            return buffer;
        }

        /// <summary>
        /// Create a timer
        /// </summary>
        /// <param name="elapsedEvent"></param>
        /// <param name="eventArgs"></param>
        /// <param name="interval">Default = 1000</param>
        /// <param name="enabled">Default = false</param>
        /// <returns>New timer</returns>
        public static Timer CreateTimer(delegateElapsedEvent elapsedEvent, object eventArgs, int interval = 1000, bool enabled = false)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler((s, e) => elapsedEvent(s, e, eventArgs));
            timer.Interval = interval;
            timer.AutoReset = true;
            timer.Enabled = enabled;
            return timer;
        }
        #endregion
    }
}
