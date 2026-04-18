namespace StockMePhotos.GCommon
{
    public static class ExceptionMessages
    {
        public static class Identity
        {
            public const string RoleSeedingExceptionMessage = "There was an error seeding the role {0}. Please see the inner exception for details.";
            public const string EmailNotFoundExceptionMessage = "{0} email not found in the configuration.";
            public const string PasswordNotFoundExceptionMessage = "{0} password not found in the configuration.";
            public const string UsernameNotFoundExceptionMessage = "{0} username not found in the configuration.";
            public const string UserSeedingExceptionMessage = "There was an error seeding the user with email {0}. Please see the inner exception for details.";
            public const string UserResetPasswordExceptionMessage = "Failed to reset password for user {0}.";
            public const string NoUsersFoundInConfiguration = "No users are found in the configuration.";
            public const string RoleAssignFailureExceptionMessage = "Can't assign user {0} to role {1}.";
        }
    }
}
