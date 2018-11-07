const router     = require('express').Router({mergeParams: true});
const controller = require('./ItensController');


router.get('/:itemId', controller.show);


module.exports = router;
