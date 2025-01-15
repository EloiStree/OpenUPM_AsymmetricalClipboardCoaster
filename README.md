# OpenUPM: Asymmetrical Clipboard Coaster

This code provides an interface designed to abstract the asymmetric signature process and serve as a bridge to a MetaMask Ethereum account for integration with a server.

Unity's compatibility with RSA and ECC encryption is limited, particularly due to the constraints of older C# versions and the challenges of implementing ECC code that works seamlessly across all platforms.

Here, I introduce a concept I call a "coaster" (or "letter marque"), which allows for a double-signature system. One signature comes from the primary key, delegating its authority to a secondary public key. This secondary key can then act on behalf of the primary key.

### Why Use This Approach?

The goal is to enable secure transactions using a key that authenticates the user/player without exposing their wallet key or requiring them to sign every time an action is needed in the app. 

The solution involves having the user sign an asymmetrical public key that the app can then use as a delegate key to act on their behalf. 

Since most gaming platforms don’t support MetaMask, the application must generate a format that can be copied (e.g., clipboard-friendly) and passed via URL parameters for seamless integration.

### Key Benefits

This tool enables game developers to incorporate asymmetric key-based actions, where one key (a "coaster") serves as a letter marque for another key. 

This pattern was developed for a service I am building called **APInt IO**. The term "coaster" is used instead of "letter marque" because the concept can be visualized as writing two signatures on a coaster, effectively proving one key’s authority to delegate to another.

Required: 
- https://github.com/EloiStree/OpenUPM_pBit4096B58Pkcs1SHA256

Python version:
- https://github.com/EloiStree/pypi_pBit4096B58Pkcs1SHA256
