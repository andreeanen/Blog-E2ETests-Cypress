/// <reference types="Cypress" />

beforeEach(() => {
    cy.visit('localhost');
})

describe('Test suite', () => 
{
     it('Login as User', () => {
        cy.get('#username')
          .type('User');

        cy.get('#password')
          .type('User');

        cy.get('#login-button')
          .click();

        cy.location('pathname')
          .should('eq', '/blog.html')
          .should(() => {
              expect(localStorage.getItem('usernameLogedIn')).to.eq('User');
              expect(localStorage.getItem('userStatus')).to.eq('0');
          });

        cy.get('#add-new-blogpost-button')
          .should('not.be.visible');

        cy.get('#create-blog-form')
          .should('not.be.visible');
    });

    it('Login as Admin', () => {
        cy.get('#username')
          .type('Admin');

        cy.get('#password')
          .type('Admin');

        cy.get('#login-button')
          .click();

        cy.location('pathname')
          .should('eq', '/blog.html')
          .should(() => {
              expect(localStorage.getItem('usernameLogedIn')).to.eq('Admin');
              expect(localStorage.getItem('userStatus')).to.eq('1');
          });

        cy.get('#add-new-blogpost-button')
          .should('be.visible');

        cy.get('#create-blog-form')
          .should('not.be.visible');
    });

    it('Write a new blogpost', () => {
        cy.login('Admin', 'Admin');

        cy.request('get', 'http://localhost:6001/api/Blogposts')
            ;

        cy.get('#add-new-blogpost-button')
          .click();

        cy.get('#title')
          .type('New Blog Title');

        cy.get('#text')
          .type('New blog text...');

        cy.get('#submit-blogpost-button')
          .click();
    });
})