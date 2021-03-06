﻿/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/22/2013
 * 时间: 1:36 PM
 * 
 */
using System;
using System.Threading;

namespace ConsoleWbClient.Domain
{
    public class ThreadContext : AbsThreadContext
    {
        private static ThreadContext instance = null;
        private MainLoop bus = null; //业务实例
        private Thread busThread = null; //业务线程

        /// <summary>
        /// 私有构造，一个appdomain里只能一个实例
        /// </summary>
        private ThreadContext()
        {
            bus = new MainLoop();
        }

        /// <summary>
        /// 获取一个退款实例
        /// </summary>
        /// <returns></returns>
        public static ThreadContext CreateInstance()
        {
            if (instance == null)
            {
                instance = new ThreadContext();
            }

            return instance;
        }

        public override void Start()
        {
            try
            {
                SystemParamSet.IsEnableThread = 1; //启用线程
                if (busThread == null || busThread.IsAlive == false)
                {
                    busThread = new Thread(new ThreadStart(bus.Excute));
                    busThread.IsBackground = true;
                    busThread.Start();
                    RaiseStartSuccessEvent("线程启动成功");
                }
                else
                {
                    RaiseStartSuccessEvent("线程处于未终止状态!");
                    return;
                }
            }
            catch (Exception ex)
            {
                RaiseStartFailedEvent("线程启动失败，原因：" + ex.ToString());
            }
        }

        public override void Abort()
        {
            SystemParamSet.IsEnableThread = 0; //停止线程
        }
    }
}
