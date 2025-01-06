using UnityEngine;

/// <summary>
/// Use to stress test server it allows to build random clients .
/// </summary>
public abstract class MaskSignerMono_AbstractBuilder : MonoBehaviour
{
    public abstract IMaskSignerCliboardable BuildSigner();
    public abstract void BuildSigner(out IMaskSignerCliboardable signer);
}
