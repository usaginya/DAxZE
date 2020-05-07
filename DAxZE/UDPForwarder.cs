using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace DAxZE
{
    public class UDPForwarder
    {
        public enum RecviceState { Running, Stop, Waiting }
        public RecviceState State { get; private set; }

        private UdpClient localClient = new UdpClient(), remoteClient = new UdpClient();
        private IPEndPoint localPoint, remotePoint;
        private Thread recviceRemoteThread, recviceLocalThread;
        private System.Timers.Timer timerCheckStatic;

        private bool runRemoteThread, runLocalThread;
        private int initCount, missCount, recviceDelay = 2;


        /// <summary>
        /// 初始化UDP转发
        /// </summary>
        /// <param name="localPoint">本地地址</param>
        /// <param name="remotePoint">远程地址</param>
        public UDPForwarder(IPEndPoint localPoint, IPEndPoint remotePoint)
        {
            State = RecviceState.Stop;
            ChangePoint(localPoint, remotePoint);
        }

        /// <summary>
        /// 修改要访问的本地地址和远程地址
        /// </summary>
        /// <param name="localPoint">本地地址</param>
        /// <param name="remotePoint">远程地址</param>
        public void ChangePoint(IPEndPoint localPoint, IPEndPoint remotePoint)
        {
            this.localPoint = localPoint;
            this.remotePoint = remotePoint;
        }

        /// <summary>
        /// 发送数据到远程地址
        /// </summary>
        public void SendToRemote(byte[] data)
        {
            remoteClient.Send(data, data.Length, remotePoint);
        }

        /// <summary>
        /// 检查断线状态
        /// </summary>
        private void CheckState(object source, ElapsedEventArgs elapsedEventArgs, object sourceArgs)
        {
            missCount++;

            if (missCount > 60)
            {
                Stop();
                timerCheckStatic.Close();
                timerCheckStatic = null;
            }
            else if (missCount > 6)
            {
                State = RecviceState.Waiting;
            }
        }

        /// <summary>
        /// 开始UDP转发
        /// </summary>
        public void Start()
        {
            try
            {
                if (!runLocalThread && !runRemoteThread)
                {
                    if (timerCheckStatic == null)
                    {
                        timerCheckStatic = WebsocketCore.CreateTimer(CheckState, null, 1000, true);
                    }

                    if (recviceRemoteThread == null)
                    {
                        recviceRemoteThread = new Thread(RecviceRemote);
                    }

                    if (recviceLocalThread == null)
                    {
                        recviceLocalThread = new Thread(RecviceLocal);
                    }

                    if (recviceRemoteThread != null && recviceLocalThread != null)
                    {
                        recviceDelay = recviceDelay == 2 ? 100 : recviceDelay;
                        if(missCount > 6)
                        {
                            initCount = missCount = 0;
                        }
                        runRemoteThread = runLocalThread = true;
                        recviceRemoteThread.Start();
                        recviceLocalThread.Start();
                        State = RecviceState.Running;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 停止UDP转发
        /// </summary>
        public void Stop()
        {
            try
            {
                if (runLocalThread && runRemoteThread)
                {
                    if (timerCheckStatic != null)
                    {
                        timerCheckStatic.Close();
                        timerCheckStatic = null;
                    }

                    if (recviceRemoteThread != null)
                    {
                        runRemoteThread = false;
                        recviceRemoteThread = null;
                    }

                    if (recviceLocalThread != null)
                    {
                        runLocalThread = false;
                        recviceLocalThread = null;
                    }

                    if (recviceRemoteThread == null && recviceLocalThread == null)
                    {
                        recviceDelay = 2;
                        State = RecviceState.Stop;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 接收远程地址发来的数据并转发到本地地址
        /// </summary>
        private void RecviceRemote()
        {
            while (runRemoteThread)
            {
                try
                {
                    byte[] data = remoteClient.Receive(ref remotePoint);

                    if (data.Length > 0)
                    {
                        missCount = 0;
                        localClient.Send(data, data.Length, localPoint);

                        if (initCount < 16)
                        {
                            initCount++;
                        }

                        if (initCount > 15)
                        {
                            recviceDelay = 1;
                        }
                    }
                }
                catch { }

                Thread.Sleep(recviceDelay);
            }
        }

        /// <summary>
        /// 接收本地地址发来的数据并转发到远程地址
        /// </summary>
        private void RecviceLocal()
        {
            while (runLocalThread)
            {
                try
                {
                    byte[] data = localClient.Receive(ref localPoint);
                    if (data.Length > 0)
                    {
                        SendToRemote(data);

                        if (initCount < 16)
                        {
                            initCount++;
                        }

                        if (initCount > 15)
                        {
                            recviceDelay = 1;
                        }
                    }
                }
                catch { }
                Thread.Sleep(recviceDelay);
            }
        }

    }
}
