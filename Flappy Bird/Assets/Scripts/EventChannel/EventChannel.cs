using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
  public delegate void EventChannelEventHandler();

  public abstract class EventChannel : MonoBehaviour
  {
    public event EventChannelEventHandler OnEventPublished;

    public void Publish()
    {
      if (OnEventPublished != null)
      {
        OnEventPublished();
      }
    }
  }
}
