const router = require('express').Router();
const controller = require('./EncomendaController');



router.get('/', controller.index);
router.get('/:id', controller.show);
router.post('/', controller.create);


module.exports = router;
