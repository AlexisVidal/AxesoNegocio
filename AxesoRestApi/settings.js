exports.dbConfig = {
    user: "dba",
    password: "@x3$0!2020",
    server: "192.168.1.100",
    database: "DBAxeso_OLTP",
    instance: "SQLAXESO",
    port: 1436,
    connectionTimeout: 300000,
    requestTimeout: 300000,
    pool: {
        idleTimeoutMillis: 300000,
        max: 100
    }
};

exports.webPort = 9000;

exports.httpMsgsFormat = "JSON";