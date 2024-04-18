using System.Security.Cryptography;

namespace TaskList_API.utils
{
    public class PasswordEncryptor
    {
        private const int SaltSize = 16; // se añade a la contraseña antes de aplicar una función de hash
        private const int keySize = 32; //tamaño de la contraseña
        private const int Interation = 100; //Número de iteraciones para la función de derivación de clave


        public static string EncryptPassword(string password)
        {
            byte[] salt = new byte[SaltSize];//generar un salt aleatorio

            using (var rng = RandomNumberGenerator.Create())//genera valores random
            {
                rng.GetBytes(salt);
            }

            //crear la clave segura a partir de la contraseña y el salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password,salt,Interation))
            {
                byte[] key = pbkdf2.GetBytes(keySize);

                //combinar el salt y la clave
                byte[] hashPassword = new byte[SaltSize+keySize];
                Array.Copy(salt,0,hashPassword,0,SaltSize);
                Array.Copy(key,0,hashPassword,SaltSize,keySize);

                // Convertir el array de bytes a una cadena base64 para retornar
                return Convert.ToBase64String(hashPassword);
            }

        }




        public static bool VerifyPassword(string password, string hashPassword)
        {
            // Convertir la cadena base64 de vuelta a un array de bytes
            byte[] hashByte = Convert.FromBase64String(hashPassword);
            byte[] salt = new byte[SaltSize];

            //extraer el salt del array
            Array.Copy(hashByte,0,salt,0,SaltSize);

            //usar la clave y el salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Interation))
            {
                byte[] key = pbkdf2.GetBytes(keySize);
                // Comparar la clave derivada con el hash almacenado
                for (int i = 0; i < keySize; i++)
                {
                    if (key[i] != hashByte[i + SaltSize])
                    {
                        // Si alguna de las partes no coincide, la contraseña es incorrecta
                        return false;
                    }
                }

                // Si todas las partes coinciden, la contraseña es correcta
                return true;
            }
        }
    }
}
