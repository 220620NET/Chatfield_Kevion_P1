using Models;
using Services;
namespace UI;

new MainMenu(new AuthService(new UserRepository())).Start();
