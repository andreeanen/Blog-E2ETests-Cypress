describe('Test suite', () => {
    it('Test that localhost is accesible', () => {
        cy.visit("http://localhost");
    })
})