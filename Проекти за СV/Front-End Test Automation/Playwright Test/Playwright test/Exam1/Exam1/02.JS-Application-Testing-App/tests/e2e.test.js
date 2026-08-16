const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let albumName = "";

 async function loginUser(page, email, password) {
        await page.goto(host);
         await page.click('text=Login');
         await page.waitForSelector('form');
         await page.locator('#email').fill(email);
         await page.locator('#password').fill(password);
        await page.click('[type="submit"]');
       await page.waitForURL(host + '/');
         await page.waitForSelector('nav >> text=Logout');



    }

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    
    
    describe("authentication", () => {
        
        test('Registration with Valid Data', async () => {
            await page.goto(host);
            await page.click('text=Register');
            await page.waitForSelector('form');
            
            let random = Math.floor(Math.random() * 10000);
           user.email = `softuni_${random}@softuni.bg`;

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#conf-pass').fill(user.confirmPass);
            await page.click('[type="submit"]');
            await page.waitForURL(host + '/');
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Login with Valid Data', async () => {
            await loginUser(page, user.email, user.password);
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
            
        });

        
        test('Logout from the Application', async () => {
            await loginUser(page, user.email, user.password);

            await page.locator('nav >> text=Logout').click();
            await page.waitForURL(host + '/');
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            expect(page.url()).toBe(host + '/');
            
        });
    });

    describe("navbar", () => {
           test('Navigation for Logged-In User', async () => {
            await loginUser(page, user.email, user.password);
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Create Album')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();


  
            
        });

           test('Navigation for Guest User', async () => {
            await page.goto(host);
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();
            await expect(page.locator('nav >> text=Catalog')).toBeVisible();
            await expect(page.locator('nav >> text=Search')).toBeVisible();
            
        });

        
    });

    describe("CRUD", () => {
           test('Create an Album Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Create Album');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 10000);
            albumName = `Album_${random}`;
            await page.fill('#name', albumName);
            await page.fill('#imgUrl', '/images/Lorde.jpg');
            await page.fill('#price', '10');
            await page.fill('#releaseDate', '2026-01-01');
            await page.fill('#artist', 'Lorde');
            await page.fill('#genre', 'Pop');
            await page.fill('[name="description"]', 'This is a test album.');
            await page.click('[type="submit"]');
            await page.waitForURL(host + '/catalog');
            await expect(page.locator(`text=${albumName}`)).toBeVisible();
            expect(page.url()).toBe(host + '/catalog');
            


  
            
        });
        test('Edit an Album Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Search');
            await page.waitForSelector('#search-input');
            await page.fill('#search-input', albumName);
            await page.click('.button-list');
            await page.locator('text=Details').first().click();
            await page.click('text=Edit');
            await page.waitForSelector('text=Edit');
            albumName = albumName + '_Edited';
            await page.locator('#name').fill(albumName);
            await page.click('[type="submit"]');
            await expect(page.locator(`text=Name: ${albumName}`)).toBeVisible();


            

  
            
        });
        test('Delete an Album Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Search');
            await page.waitForSelector('#search-input');
            await page.fill('#search-input', albumName);
            await page.click('.button-list');
            await page.locator('text=Details').first().click();
            await page.click('text=Delete');
            await page.waitForURL(host + '/catalog');
            expect(page.url()).toBe(host + '/catalog');
            await expect(page.locator(`text=${albumName}`)).not.toBeVisible();


            


  
            
        });
    });
});