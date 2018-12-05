const router     = require('express').Router();
const controller = require('./produtoscontroller');

router.get('/', controller.list);


module.exports = router;
