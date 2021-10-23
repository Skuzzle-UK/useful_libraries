## Simple Encryption

Designed to make practically unbreakable passwords.
Use the executable to encrypt and decrypt phrases or use encryption.cs in your projects.

Encryption that requires a unique identifier / passphrase provided during encryption and required to decrypt.

*Dont lose the identifier or you'll never get the data back.*

## Suggested use:
---
### Using class within another application
- Include class into your application.
- Pass data as a string by calling `encrypt(data, identifier);`, returns a string of hexadecimal where data is that data string and identifier is your unique identifier string.
- Get data back by passing the encrypted hexstring through decrypt(hexstring, identifier), returns the data as a string.

---
### Standalone
Small console app is run via void main when compiled and executed, which can encrypt and decrypt using the algorithm.

Standalone encryption.exe is included to test out the app or just to use it in the most straight forward way possible.

*Release folder contains executable file*

---
### Ideas to play with encryption.exe
- Encrypt the phrase "Hello World" using identifier "password123". This will give the string "0066002600430036001600630026003600330036005600660036005600730013005600430073005600460003009300730036009300630026002300460026001600660043005300830016001600130083007300330026002300030046005300660026001300160036001600630066005600160013002600560066006600130063007300130066001600630073003600530066001600230063008300130063003600030013000300260066002600660036005600230053001600930036005600030073002300830073001600230016006300460053000300730033004600260043005300930046002600460066004300460013001600660056004300460056002600430083000300030063005300030003006300340003000300630034000300030063006400030003002300030003000300530073000300030063006400030003007300230003000300630034000300030063004300030003"
- Decrypt it back to "Hello World".
- Save your password list in a .txt file encrypted so that you can easily decrypt later, as long as you can remember the unique identifier that you used........
