db.createUser(
    {
        user : "StarWarsQL-User",
        pwd: "userP4ssw0rd381!",
        roles: [
            {
                role: "readWrite",
                db: 'StarWarsQL'
            }
        ]
    }
)