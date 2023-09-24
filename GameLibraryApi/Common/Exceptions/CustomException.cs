using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryApi.Common.Exceptions
{
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

    public static class CustomExceptions
    {
        public static CustomException NOT_FOUND = new CustomException(700, "NOT_FOUND", "There is no record with this id.");
        public static CustomException LOGIN_ERROR = new CustomException(701, "LOGIN_ERROR", "Wrong Username or Password!");
        public static CustomException ALREADY_REGISTERED = new CustomException(702, "ALREADY_REGISTERED", "User already registered, pick another username");
    }
}