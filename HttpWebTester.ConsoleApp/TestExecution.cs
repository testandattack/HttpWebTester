using HttpWebTesting;
using HttpWebTesting.Rules;
using HttpWebTesting.WebTestItems;
using System;
using System.Net.Http;
using WebTestExecutionEngine;

namespace HttpWebTester.ConsoleApp
{
    public class ExecuteTests
    {
        public void ExecuteTheTests()
        {
            Console.WriteLine("Hello World!");
            WTI_Request request = new WTI_Request();
            request.ThinkTime = 10;
            request.itemComment = "Chris is silly";
            request.ReportingName = "Rubber Baby Buggy Bumpers";
            request.requestItem = new HttpRequestMessage(HttpMethod.Get, "http://www.bing.com");

            RequestExecution requestExecution = new RequestExecution(request);

            //MyCustomPreRequestPlugin plugin = new MyCustomPreRequestPlugin();
            //request.PreRequest += plugin.PreRequest;

            PreRequestEventArgs args = new PreRequestEventArgs();
            args.requestItem = request;
            //requestExecution.PreRequestPreDataBinding(requestExecution, args);

            requestExecution.AddPreRequestHandler();

            Console.WriteLine("Finished Test");
        }
    }
    //public class MyCustomPreRequestPlugin : RequestPlugin
    //{
    //    public override void PreRequest(object sender, PreRequestPreDataBingingEventArgs e)
    //    {
    //        e.requestItem.itemComment = "New Comment";
    //    }

    //    public override void PostRequest(object sender, PostRequestEventArgs e)
    //    {
    //        base.PostRequest(sender, e);
    //    }
    //}


    // -- Showing usage of delegates
    #region delegates
    public class CustomClass
    {
        public void OnCommand()
        {
            Console.WriteLine("Called OnCommand From CustomClass");
        }
    }

    public class ActionClass
    {
        // Create Delegate
        public delegate void actionClassDelegate();

        // Create Delegate Instance
        public actionClassDelegate actionClassDelegateInstance;

        public void PerformAnAction()
        {
            if (actionClassDelegateInstance != null)
            {
                actionClassDelegateInstance();
            }
            else
            {
                Console.WriteLine("No delegate instance found");
            }
        }
    }
    #endregion

    // -- Showing usage of delegates
    #region events

    /*
    Declare a delegate (actionClassEventHandler)
    Declare an event based on that delegate (actionClassEvent)
    Create an event (actionClassEvent(this, EventArgs.Empty);)
    Subscribe methods to that event(actionClass2.actionClassEvent += customClass2.OnEvent)
    Fire that event (PerformAnAction)
    */
    // Class that contains the extra code to run
    public class CustomClass2
    {
        public void OnEvent(object source, EventArgs e)
        {
            Console.WriteLine("Called OnEvent From CustomClass2");
        }
    }

    // Class that wants to be extendable
    public class ActionClass2
    {
        // Create Delegate
        public delegate void actionClassEventHandler(object source, EventArgs e);
        // Create Event Instance
        public event actionClassEventHandler actionClassEvent;

        // ALTERNATE Syntax for combining above two lines
        public event EventHandler secondActionClassEvent;

        public void PerformAnAction()
        {
            if (actionClassEvent != null)
            {
                actionClassEvent(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("No delegate instance found");
            }

            if (secondActionClassEvent != null)
            {
                secondActionClassEvent(this, EventArgs.Empty);
            }
        }
    }
    #endregion


}
