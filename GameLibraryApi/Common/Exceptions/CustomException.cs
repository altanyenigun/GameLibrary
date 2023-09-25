using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryApi.Common.Exceptions
{
    // base class to use to create CustomError
    public class CustomException : Exception
    {
        public int ErrorCode { get; }
        public string Error { get; }

        public CustomException(int errorCode, string error, string message) : base(message)
        {
            ErrorCode = errorCode;
            Error = error;
        }
    }
    // Creating special error definitions for error situations that may occur in the flow
    public static class CustomExceptions
    {
        public static CustomException NOT_FOUND = new CustomException(700, "NOT_FOUND", "There is no record with this id.");
        public static CustomException LOGIN_ERROR = new CustomException(701, "LOGIN_ERROR", "Wrong Username or Password!");
        public static CustomException ALREADY_REGISTERED = new CustomException(702, "ALREADY_REGISTERED", "User already registered, pick another username");
        public static CustomException ALREADY_OWN_GAME = new CustomException(703, "ALREADY_OWN_GAME", "The user already own this game");
        public static CustomException DOESNT_HAVE_GAME = new CustomException(704, "DOESNT_HAVE_GAME", "The user does not already own this game.");

    }
}