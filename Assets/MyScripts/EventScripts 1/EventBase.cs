using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase
{
    //事件总线模式
    private static readonly Dictionary<Type, List<Delegate>> eventDictionary = new Dictionary<Type, List<Delegate>>();


    // 订阅事件的方法，接收一个泛型EventArgs 或其子类作为参数
    public static void Subscribe<T>(Action<T> listener) where T : EventArgs
    {
        // 获取事件的类型
        Type eventType = typeof(T);

        // 检查事件字典中是否已经包含该事件类型
        if (!eventDictionary.ContainsKey(eventType))
        {
            // 如果不包含，则为该事件类型创建一个新的委托列表
            eventDictionary[eventType] = new List<Delegate>();
        }

        // 将订阅者的委托添加到该事件类型的委托列表中
        eventDictionary[eventType].Add(listener);
    }

    // 取消订阅事件的方法，接收一个泛型EventArgs 或其子类作为参数
    public static void Unsubscribe<T>(Action<T> listener) where T : EventArgs
    {
        // 获取事件的类型
        Type eventType = typeof(T);

        // 检查事件字典中是否包含该事件类型
        if (eventDictionary.ContainsKey(eventType))
        {
            // 如果包含，则从该事件类型的委托列表中移除订阅者的委托
            eventDictionary[eventType].Remove(listener);
        }
    }

    // 发布事件的方法，接收一个泛型EventArgs 或其子类作为参数
    public static void Publish<T>(T eventArgs) where T : EventArgs
    {
        // 获取事件的类型
        Type eventType = typeof(T);

        // 检查事件字典中是否包含该事件类型
        if (eventDictionary.ContainsKey(eventType))
        {
            // 如果包含，则遍历该事件类型的委托列表
            foreach (Delegate listener in eventDictionary[eventType])
            {
                // 将委托转换为具体的泛型委托类型
                if (listener is Action<T> action)
                {
                    // 调用委托，并传入事件参数
                    action.Invoke(eventArgs);
                }
            }
        }
    }

}


/*
 // 示例事件类，继承自 EventArgs 类
// 用于传递事件相关的信息
public class ExampleEventArgs : EventArgs
{
    // 定义一个公共属性，用于存储事件消息
    public string Message { get; set; }

    // 构造函数，用于初始化事件消息
    public ExampleEventArgs(string message)
    {
        Message = message;
    }
}

// 示例订阅者类，用于订阅事件并处理事件消息
public class ExampleSubscriber
{
    // 构造函数，在实例化时订阅事件
    public ExampleSubscriber()
    {
        // 调用事件总线的订阅方法，订阅 ExampleEventArgs 类型的事件
        // 并指定事件处理方法为 OnExampleEvent
        EventBus.Subscribe<ExampleEventArgs>(OnExampleEvent);
    }

    // 事件处理方法，当接收到 ExampleEventArgs 类型的事件时被调用
    private void OnExampleEvent(ExampleEventArgs eventArgs)
    {
        // 输出接收到的事件消息到 Unity 控制台
        UnityEngine.Debug.Log($"Received event with message: {eventArgs.Message}");
    }

    // 取消订阅方法，用于在不需要处理事件时取消订阅
    public void Unsubscribe()
    {
        // 调用事件总线的取消订阅方法，取消订阅 ExampleEventArgs 类型的事件
        // 并指定事件处理方法为 OnExampleEvent
        EventBus.Unsubscribe<ExampleEventArgs>(OnExampleEvent);
    }
}

// 示例发布者类，用于发布事件
public class ExamplePublisher
{
    // 发布事件的方法
    public void PublishEvent()
    {
        // 调用事件总线的发布方法，发布一个 ExampleEventArgs 类型的事件
        // 并传入事件消息
        EventBus.Publish(new ExampleEventArgs("This is an example event message."));
    }
}
 */