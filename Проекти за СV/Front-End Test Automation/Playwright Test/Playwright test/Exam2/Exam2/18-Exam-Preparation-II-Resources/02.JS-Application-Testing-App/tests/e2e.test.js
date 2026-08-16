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

let petName = "";

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
           await page.locator('#repeatPassword').fill(user.confirmPass);
           await page.click('[type="submit"]');
           await page.waitForURL(host + '/');
            await expect(page.locator('nav >> text=Logout')).toBeVisible();
        expect(page.url()).toBe(host + '/');


        })

        test('Login with Valid Data', async () => {
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');
            await page.waitForURL(host + '/');
             await expect(page.locator('nav >> text=Logout')).toBeVisible();
        expect(page.url()).toBe(host + '/');

        })

        test('Logout from the Application', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Logout');
            await expect(page.locator('nav >> text=Login')).toBeVisible();
        expect(page.url()).toBe(host + '/');

        })
    })

    describe("navbar", () => {
        test('Navigation for Logged-In User Testing', async () => {
            await loginUser(page, user.email, user.password);
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Dashboard')).toBeVisible();
            await expect(page.locator('nav >> text=Create Postcard')).toBeVisible();
            await expect(page.locator('nav >> text=Logout')).toBeVisible();

            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden();

        })

        test('Navigation for Guest User Testing', async () => {
            await page.goto(host);
            await expect(page.locator('nav >> text=Home')).toBeVisible();
            await expect(page.locator('nav >> text=Dashboard')).toBeVisible();
            await expect(page.locator('nav >> text=Login')).toBeVisible();
            await expect(page.locator('nav >> text=Register')).toBeVisible();

            await expect(page.locator('nav >> text=Logout')).toBeHidden();
            await expect(page.locator('nav >> text=Create Postcard')).toBeHidden();
        })
    });

    describe("CRUD", () => {

        test('Create a Postcard Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Create Postcard');
            await page.waitForSelector('form');

            const random = Math.floor(Math.random() * 10000);
            petName = `Pet_${random}`;

             await page.locator('#name').fill(petName);
             await page.locator('#breed').fill('dog');
             await page.locator('#age').fill('5');
             await page.locator('#weight').fill('5');
             await page.locator('#image').fill('/image/dog2.jpg');
             await page.click('[type="submit"]');
             await page.waitForURL(host + '/catalog');

              await expect(page.locator(`text=${petName}`)).toBeVisible();
        expect(page.url()).toBe(host + '/catalog');




        })

        test('Edit a Postcard Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Dashboard');
            const divlocator = page.locator(`div.animals-board:has(h2.name:text("${petName}"))`); 
            await divlocator.locator('text=Details').click();
            await page.click('text=Edit');
            await page.waitForSelector('text=Edit');
             petName = petName + '_Edited';
            await page.locator('#name').fill(petName);
            await page.click('[type="submit"]');

             await expect(page.locator(`text=${petName}`)).toBeVisible();
        

        })
        test('Delete a Postcard Testing', async () => {
            await loginUser(page, user.email, user.password);
            await page.click('text=Dashboard');
            const divlocator = page.locator(`div.animals-board:has(h2.name:text("${petName}"))`); 
            await divlocator.locator('text=Details').click();
            await page.click('text=Delete');

            await expect(page.locator(`text=${petName}`)).not.toBeVisible();
        expect(page.url()).toBe(host + '/catalog');

        })

        
        
    });
})