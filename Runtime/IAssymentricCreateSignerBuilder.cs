
/// <summary>
/// Allow to vreate assymetric key to signa and verify message
/// </summary>
public interface IAssymentricCreateSignerBuilder { 

    public IAssymentricCreateSignVerify BuildSigner();
    public void BuildSigner(out IAssymentricCreateSignVerify signer);

}
