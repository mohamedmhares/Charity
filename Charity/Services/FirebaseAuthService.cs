using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace Charity.Services
{
    public class FirebaseAuthService
    {
        // Firebase configuration
        private static readonly FirebaseAuthConfig Config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyC7-wHDSdzyO1VlHdP68_b1LFRakbrjHco",
            AuthDomain = "test-a6c53.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider(),
            }
        };

        // Firebase client instance
        private static readonly FirebaseAuthClient Client = new FirebaseAuthClient(Config);

        /// <summary>
        /// Creates a new user account after checking if the user already exists.
        /// </summary>
        public async Task<string> CreateAsync(string email, string password)
        {
            try
            {
                // Check if the user already exists by attempting to log in
                var userId = await CheckIfUserExistsAsync(email, password);
                if (!string.IsNullOrEmpty(userId))
                {
                    // If the user exists, throw an exception or return a message
                    throw new ApplicationException("User already exists with this email.");
                }

                // If the user doesn't exist, create a new user
                var result = await Client.CreateUserWithEmailAndPasswordAsync(email, password);
                return result.User.Uid; // Return the unique user ID
            }
            catch (Exception ex)
            {
                // Handle exceptions and provide meaningful feedback
                throw new ApplicationException($"Error creating user: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        public async Task<string> LoginAsync(string email, string password)
        {
            try
            {
                var result = await Client.SignInWithEmailAndPasswordAsync(email, password);
                return result.User.Uid; // Return the unique user ID
            }
            catch (Exception ex)
            {
                // Handle exceptions and provide meaningful feedback
                throw new ApplicationException($"Error logging in: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Checks if the user already exists by attempting to log in.
        /// </summary>
        private async Task<string> CheckIfUserExistsAsync(string email, string password)
        {
            try
            {
                var result = await Client.SignInWithEmailAndPasswordAsync(email, password);
                return result.User.Uid; // Return the user ID if successful
            }
            catch (Exception)
            {
                // If login fails, it means the user doesn't exist
                return null;
            }
        }
    }
}
