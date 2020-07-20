var express = require('express');
var router = express.Router();
var sqlDb = require("mssql");
var settings = require("../settings");
var db = require('../helpers/dbconfig');

router.get('/getList/', function (req, res, next) {
    var conn = new sqlDb.Connection(settings.dbConfig);
    conn.connect()
        .then(function () {
            var request = new sqlDb.Request(conn);
            request.execute('GetListUsuarios', function (err, recordsets, returnValue, affected) {
                if (err) {
                    res.json(err);
                    console.log("error:" + err);
                } else {
                    res.json(recordsets[0]);
                }
            });
        }).catch(function (err) {
            console.log(err);
        });
});
router.post('/get/', function (req, res, next) {
    if (!req.body) {
        res.json("Valor no valido");
    } else {
        var conn = new sqlDb.Connection(settings.dbConfig);
        conn.connect()
            .then(function () {
                var request = new sqlDb.Request(conn);
                request.input('Usuario', sqlDb.VarChar(128), req.param('Usuario'));
                request.execute('GetUsuarios', function (err, recordsets, returnValue, affected) {
                    if (err) {
                        res.json(err);
                        console.log("error:" + err);
                    } else {
                        res.json(recordsets[0]);
                    }
                });
            }).catch(function (err) {
                console.log(err);
            });
    }
});
router.post('/add/', function (req, res, next) {
    if (!req.body) {
        res.json("Valor no valido");
    } else {
        var conn = new sqlDb.Connection(settings.dbConfig);
        conn.connect()
            .then(function () {
                var request = new sqlDb.Request(conn);
                request.input('TipoUsuarioID', sqlDb.Char(1), req.param('TipoUsuarioID'));
                request.input('Usuario', sqlDb.VarChar(128), req.param('Usuario'));
                request.input('Descripcion', sqlDb.VarChar(120), req.param('Descripcion'));
                request.output('new_identity', sqlDb.Int());
                request.execute('InsertUsuarios', function (err, recordsets, returnValue, affected) {
                    if (err) {
                        res.json(err);
                        console.log("error:" + err);
                    } else {
                        res.json(request.parameters.new_identity.value);
                    }
                });
            }).catch(function (err) {
                console.log(err);
            });
    }
});

router.post('/login/', function (req, res, next) {
    if (!req.body) {
        res.json("Valor no valido");
    } else {

        var conn = new sqlDb.Connection(settings.dbConfig);
        conn.connect()
            .then(function () {
                var request = new sqlDb.Request(conn);
                request.input('Usuario', sqlDb.VarChar(128), req.param('Usuario'));
                request.input('Token', sqlDb.NVarChar(128), req.param('Token'));
                request.execute('LoginUsuarios', function (err, recordsets, returnValue, affected) {
                    if (err) {
                        res.json(err);
                        console.log("error:" + err);
                    } else {
                        res.json(recordsets[0]);
                    }
                });
            }).catch(function (err) {
                console.log(err);
            });
    }
});
router.post('/updatepassusuarios/', function (req, res, next) {
    if (!req.body) {
        res.json("Valor no valido");
    } else {

        var conn = new sqlDb.Connection(settings.dbConfig);
        conn.connect()
            .then(function () {
                var request = new sqlDb.Request(conn);
                request.input('UsuarioID', sqlDb.Int(), req.param('UsuarioID'));
                request.input('Token', sqlDb.NVarChar(128), req.param('Token'));
                request.execute('UpdatePassUsuarios', function (err, recordsets, returnValue, affected) {
                    if (err) {
                        res.json(err);
                        console.log("error:" + err);
                    } else {
                        res.json(recordsets[0]);
                    }
                });
            }).catch(function (err) {
                console.log(err);
            });
    }
});
module.exports = router;
