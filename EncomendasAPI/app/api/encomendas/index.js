const router = require('express').Router();
const controller = require('./EncomendaController');



router.get('/', controller.index);
router.get('/:id', controller.show);
router.post('/', controller.create);
router.delete('/:id', controller.remove);
router.put('/:id', controller.edit);

router.use('/:encomendaId/Itens', require('./itens'));

module.exports = router;
