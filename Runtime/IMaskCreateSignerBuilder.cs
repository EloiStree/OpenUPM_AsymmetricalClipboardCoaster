
/// <summary>
/// Allow to vreate assymetric key to signa and verify message
/// </summary>
public interface IMaskCreateSignerBuilder { 

    public IAssymentricMaskCreateSignVerify BuildSigner();
    public void BuildSigner(out IAssymentricMaskCreateSignVerify signer);

}
