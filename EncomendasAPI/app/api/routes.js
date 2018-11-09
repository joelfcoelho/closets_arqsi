const router = require('express').Router();              // get an instance of the express Router

// ROUTES FOR OUR API
// =============================================================================
router.get('/', (req, res,next) => res.send({ok: true}));
router.post('/', (req, res,next) => res.send({ok: req.body.text}));


router.use('/encomenda', require('./encomendas'));


module.exports = router;
