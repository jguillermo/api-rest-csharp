namespace application.Context.User.Domain
{
    public class User
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public static User create(string id, string name)
        {
            var user = new User {Id = id, Name = name};
            return user;
        }
    }
}