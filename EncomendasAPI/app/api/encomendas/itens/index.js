const router     = require('express').Router({mergeParams: true});
const controller = require('./ItensController');


router.get('/', controller.index);
router.get('/:itemId', controller.show);


module.exports = router;
