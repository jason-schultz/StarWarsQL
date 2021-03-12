FROM node:latest
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY package.json ./
RUN yarn install --production --silent && mv node_modules ../
COPY ./ ./
EXPOSE 8181
CMD ["node", "index.ts"]
