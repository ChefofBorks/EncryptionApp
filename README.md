# EncryptionApp v1.0.0.0

EncryptionApp is a .NET 8 command-line utility for encrypting and decrypting strings using AES symmetric encryption.

* [About](#About)
* [Prerequisites](#Prerequisites)
* [Setup](#Setup)
* [Usage](#Usage)
* [Security Notes](#security-notes)
* [License](#License)


## About

The application is built as a global .NET CLI tool and supports:
- AES string encryption/decryption
- PBKDF2 password-based key derivation
- Secure hidden password input
- Cross-platform execution

- The encrypted payload includes: ```[salt][iv][ciphertext]``` encoded as Base64.

---

# Prerequisites

- .NET 8 SDK


# Setup

- ### Package the Tool

	- ```dotnet pack -c Release```

	- This creates a NuGet tool package: ```bin/Release/EncryptionApp.1.0.0.nupkg```

- ### Installing the Tool
	- From the project root: ```dotnet tool install --global --add-source ./bin/Release EncryptionApp```

	- Verify installation: ```dotnet tool list --global```

- ### Updating the Tool

	- After making changes: ```dotnet pack -c Release```

	- Then update the installed tool: ```dotnet tool update --global --add-source ./bin/Release EncryptionApp```
	
- ### Uninstalling the Tool
	- ```dotnet tool uninstall --global EncryptionApp```

- ### Development

	- Run locally without installing globally: 
		- Encrypt: ```dotnet run -- encrypt "HelloWorld"```
		- Decrypt: ```dotnet run -- decrypt "EncryptedText```

# Usage

### Encryption
- Encrypt Text: ```encryptapp encrypt "HelloWorld"```

- You will be prompted for a password: ```Enter password: ********```

- Output: ```Base64EncryptedStringHere```

### Decryption
- Decrypt Text: ```encryptapp decrypt "Base64EncryptedStringHere"```

- You will be prompted for the password used during encryption.

- Output: ```HelloWorld```

### Help

- Display application help: ```encryptapp --help```

- Display command help: 
	- ```encryptapp encrypt --help```
	- ```encryptapp decrypt --help```



# Security Notes

EncryptionApp currently uses:

- AES symmetric encryption
- PBKDF2 (`Rfc2898DeriveBytes`)
- SHA256 hashing
- Random salt generation
- Random IV generation

This project is intended for educational and internal tooling purposes.

For production environments, consider adding:

- AES-GCM authenticated encryption
- Secure key storage
- Azure Key Vault / AWS KMS
- Windows Credential Manager
- macOS Keychain
- Hardware Security Modules (HSM)

---

## License

MIT