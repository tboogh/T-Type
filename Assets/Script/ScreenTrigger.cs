using UnityEngine;

namespace Assets.Script
{
    public abstract class ScreenTrigger : MonoBehaviour, ITrigger
    {
        void OnTriggerEnter(Collider other)
        {
            var responder = other.GetComponent<IResponder>();
            if (responder == null)
                return;
		
            responder.Respond(this);
        }
    }
}