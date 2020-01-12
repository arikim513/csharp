using System;

/*
イベントの宣言と使用手順
１．delegator宣言
２．宣言したdelegatorのinstanceにevent限定子を付ける
３．event handler作成
４．class instance生成し、客体のeventにevent handlerを登録
５．event 発生→event handler呼出
※delegator宣言とイベントの違い
　delegatorはpublic, internalの場合はOK
 （用途：callback）
　イベントはクラスの外部では呼出不可
 （用途：事件発生の通知や客体の状態変更を内部限定にしたい場合）
*/
namespace EventTest
{
    //delegator宣言
    delegate void MyEventHandler(string message);

    class MyNotifier
    {
        //宣言したdelegatorのinstanceにevent限定子を付ける
        public event MyEventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if(temp != 0 && temp%3 == 0)
            {
                //event 発生→event handler呼出
                //②イベント発生
                SomethingHappened(String.Format("{0} : clap!!", number));
            }
        }
    }

    　
    class MainApp
    {
        //event handler作成
        static public void MyHandler(string message)
        {
            //event 発生→event handler呼出
            //③発生したイベントを処理
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            //class instance生成し、
            //客体のeventにevent handlerを登録
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new MyEventHandler(MyHandler);

            for(int i=1;i<30; i++)
            {
                //event 発生→event handler呼出
                //①
                notifier.DoSomething(i);
            }
        }
    }
}

