const router = require('express').Router();              // get an instance of the express Router
//const auth   = require('./middleware/auth.middleware');
// ROUTES FOR OUR API
// =============================================================================
router.get('/', (req, res) => {
    res.status(200).json({ message: 'Hooray! Welcome to our api!' });
});

/*router.use('/auth', require('./auth'));
router.use('/apresentacoes', require('./apresentacoes'));
router.use('/chart', require('./chart'));
router.use('/farmacos', auth.isAuthenticated(), auth.hasRole('medico'), require('./farmacos'));
router.use('/medicamentos', auth.isAuthenticated(), auth.hasRole('medico'), require('./medicamentos'));
router.use('/receitas', auth.isAuthenticated(), require('./receitas'));
router.use('/utentes', auth.isAuthenticated(), auth.hasRole('utente'), require('./utente'));
router.use('/utilizadores', auth.isAuthenticated(), require('./utilizadores'));*/

module.exports = router;
