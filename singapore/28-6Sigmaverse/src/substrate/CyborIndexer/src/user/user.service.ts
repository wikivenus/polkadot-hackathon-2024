import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository, getRepository, DeleteResult } from 'typeorm';
import { UserEntity } from './user.entity';
import {CreateUserDto, LoginUserDto, UpdateUserDto} from './dto';
const jwt = require('jsonwebtoken');
import { SECRET } from '../config';
import { UserRO } from './user.interface';
import { validate } from 'class-validator';
import { HttpException } from '@nestjs/common/exceptions/http.exception';
import { HttpStatus } from '@nestjs/common';
import * as argon2 from 'argon2';

@Injectable()
export class UserService {
  constructor(
    @InjectRepository(UserEntity)
    private readonly userRepository: Repository<UserEntity>
  ) {}

  async findAll(): Promise<UserEntity[]> {
    return await this.userRepository.find();
  }

  async findOne({address, chain}: LoginUserDto): Promise<UserEntity> {
    const user = await this.userRepository.findOne({address: address, chain: chain});
    if (!user) {
      return null;
    }

    return user;
  }

  async create(dto: CreateUserDto): Promise<UserRO> {
    const {address, chain, email, x, tg} = dto;
    const qb = await getRepository(UserEntity)
      .createQueryBuilder('user')
      .where('user.address = :address AND user.chain = :chain', { address, chain });
    const user = await qb.getOne();

    if (user) {
      return this.buildUserRO(user);
    }

    // create new user
    let newUser = new UserEntity();
    newUser.address = address;
    newUser.chain = chain;
    newUser.email = email;
    newUser.tg = tg;
    newUser.x = x;

    const errors = await validate(newUser);
    if (errors.length > 0) {
      const _errors = {username: 'Userinput is not valid.'};
      throw new HttpException({message: 'Input data validation failed', _errors}, HttpStatus.BAD_REQUEST);

    } else {
      const savedUser = await this.userRepository.save(newUser);
      return this.buildUserRO(savedUser);
    }
  }

  async update(id: number, dto: UpdateUserDto): Promise<UserEntity> {
    let toUpdate = await this.userRepository.findOne(id);
    let updated = Object.assign(toUpdate, dto);
    return await this.userRepository.save(updated);
  }

  async delete(address: string, chain: string): Promise<DeleteResult> {
    return await this.userRepository.delete({ address: address, chain: chain});
  }

  async findById(id: number): Promise<UserRO>{
    const user = await this.userRepository.findOne(id);

    if (!user) {
      const errors = {User: ' not found'};
      throw new HttpException({errors}, 401);
    }

    return this.buildUserRO(user);
  }

  async findByAddressAndChain(address: string, chain: string): Promise<UserRO>{
    const user = await this.userRepository.findOne({address: address, chain: chain});
    return this.buildUserRO(user);
  }

  async findByEmail(email: string): Promise<UserRO>{
    const user = await this.userRepository.findOne({email: email});
    return this.buildUserRO(user);
  }

  public generateJWT(user) {
    let today = new Date();
    let exp = new Date(today);
    exp.setDate(today.getDate() + 60);

    return jwt.sign({
      id: user.id,
      address: user.address,
      chain: user.chain,
      email: user.email,
      x: user.x,
      tg: user.tg,
      exp: exp.getTime() / 1000,
    }, SECRET);
  };

  private buildUserRO(user: UserEntity) {
    const userRO = {
      id: user.id,
      address: user.address,
      chain: user.chain,
      email: user.email,
      tg: user.tg,
      x: user.x,
    };

    return {user: userRO};
  }
}