using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

public class UIManager
{
    // The Singleton's constructor should always be private to prevent
    // direct construction calls with the `new` operator.
    private UIManager() { }

    // The Singleton's instance is stored in a static field. There there are
    // multiple ways to initialize this field, all of them have various pros
    // and cons. In this example we'll show the simplest of these ways,
    // which, however, doesn't work really well in multithreaded program.
    private static UIManager _instance;

    // This is the static method that controls the access to the singleton
    // instance. On the first run, it creates a singleton object and places
    // it into the static field. On subsequent runs, it returns the client
    // existing object stored in the static field.

    public static UIManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new UIManager();
        }
        return _instance;
    }

    public void mostrarMensaje(string mensaje)
    {
        Debug.Log(mensaje);
    }
}
