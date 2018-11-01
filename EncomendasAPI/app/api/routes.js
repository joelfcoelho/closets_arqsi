const router = require('express').Router();              // get an instance of the express Router

// ROUTES FOR OUR API
// =============================================================================
router.get('/', (req, res) => {
    res.status(200).json({ message: 'Welcome to our api!' });
});


router.use('/encomenda', require('./encomendas'));


module.exports = router;
