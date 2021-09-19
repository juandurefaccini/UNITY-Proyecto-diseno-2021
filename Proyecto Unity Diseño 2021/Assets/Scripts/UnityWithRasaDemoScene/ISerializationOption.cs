using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializationOption
{
    string ContentType { get; }
    T Deserialize<T>(string json);
}
