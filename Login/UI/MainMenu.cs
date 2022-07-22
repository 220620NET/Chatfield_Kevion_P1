// using Models;
// // using Services;
// using DataAccess;
// // Create a UserName

// namespace UI;
    
//     public static class MainMenu
//     {
//         private readonly Authservice _auth;
//         public MainMenu(AuthService auth)
//         {
//             _auth = auth;
//         }
//         public static void Start()
//         {
//            while(true)
//             {
//             Console.WriteLine("Welcome to ERS!");
//             Console.WriteLine("Please select from the following: ");
//             Console.WriteLine("[1] Returning User \n[2] NEW User \n[0] Exit");
//             int userInput = Convert.Int32(Console.ReadLine());
//                 switch (userInput)
//                 {
//                     case 1:
//                         User();
//                         break;
//                     case 2:
//                         Registration();
//                         break;
//                     case 0:
//                         Console.WriteLine("Thanks for visiting us. Have a great day!");
//                         Environment.Exit(0);
//                         break;
//                     default:
//                         Console.WriteLine("Try using only numbers. Something went wrong.");
//                 }        
//             } 
//         }


//     private void Registration()
//     {
//         User newuser = new User();
        
//         bool continued = true;
//         do
//         {    
//         Console.WriteLine("Welcome to Expense Reimbursements System Registration! ");
//         Console.WriteLine("Create your USERNAME below: \n Username are required to have less than 20 characters.");
//         string _username = Console.ReadLine();
//         Console.WriteLine("Create your PASSWORD:");
//         string password = Console.ReadLine();
//         Console.WriteLine("Thanks");
//         Console.WriteLine("Please enter your 6-digit User ID number.");
//         int _userid = Convert.Int64(Console.ReadLine());
//         Console.WriteLine("Select your current: \n[1] Associate \n[2] Manager");
//         int userRole = Convert.Int32(Console.ReadLine());
//             switch (userRole)
//             {   
//                 case 1:
//                     Roles.role = "Associate";
//                     Start();
//                     break;
//                 case 2:
//                     Roles.role = "Manager";
//                     Start();
//                     break;
//                 default:
//                     Console.WriteLine("No problem! Try again with lowercase letters.");
//                     break;
//             } while(continued);

//             User registerANewUser = new User
//             {
//                 Userid = _userid,
//                 Username = _username,
//                 Password = password,
//                 Role = role
//             };
//             try
//             {
//                 User user = _auth.Registration(registerANewUser);
//             }
//             catch (InputInvalidException ex)
//             {
                
//                 Console.WriteLine("Sorry, Database issue. Please Try Again!");
//             }
//             catch (DuplicateRecordException ex)
//             {
//                 Console.WriteLine("Sorry, That Username has already been taken. Please Try Again!");
//             }
            
//         }    
//     }
// }