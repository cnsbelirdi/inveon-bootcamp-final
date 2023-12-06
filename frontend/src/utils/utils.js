const generateRandomId = () => {
  const randomFloat = Math.random(); // 0 ile 1 arasında bir ondalık sayı
  const randomInt = Math.floor(randomFloat * 100); // 0 ile 100 arasında bir tamsayı
  return randomInt;
};

export { generateRandomId };
